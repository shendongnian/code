    public class VerificationForm : CaptureForm
	{
		public void Verify(DPFP.Template template)
		{
			Template = template;
           
			ShowDialog();
		}
		protected override void Init()
		{
			base.Init();
			base.Text = "Fingerprint Verification";
			Verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
			UpdateStatus(0);
		}
        bool found = false; string fname = "";
		protected override void Process(DPFP.Sample Sample)
		{
			base.Process(Sample);
			// Process the sample and create a feature set for the enrollment purpose.
			DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
			// Check quality of the sample and start verification if it's good
			// TODO: move to a separate task
            if (features != null)
            {
                // Compare the feature set with our template
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                string[] flist = Directory.GetFiles("c:/finger");
                int mx = flist.Length;
                int cnt = 0;
                bool found = false;
               
                 DPFP.Template templates;
                while (cnt < mx && !found)
                {
                   // MessageBox.Show(flist[cnt]);
                    using (FileStream fs = File.OpenRead(flist[cnt]))
                    {
                         templates = new DPFP.Template(fs);
                        Verificator.Verify(features, templates, ref result);
                        UpdateStatus(result.FARAchieved);
                    }
                    if (result.Verified)
                    {
                        found = true;
                        FileInfo nfo = new FileInfo(flist[cnt]);
                        fname = nfo.Name;                        
                        break;
                    }
                    else
                    {
                        found = false;
                        cnt++;
                    }
                }
              
            
                    if (found)
                    {
                        MakeReport("The fingerprint was VERIFIED. "+fname);
                        MessageBox.Show("Verified!!");
                        
                    
                        
                    }
                    else
                    {
                        MakeReport("The fingerprint was NOT VERIFIED.");
                        MessageBox.Show("Not Verified!!");
                    }
                
            }
		}
		private void UpdateStatus(int FAR)
		{
			// Show "False accept rate" value
			SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
		}
		private DPFP.Template Template;
		private DPFP.Verification.Verification Verificator;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(693, 373);
            this.Name = "VerificationForm";
            this.Load += new System.EventHandler(this.VerificationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
