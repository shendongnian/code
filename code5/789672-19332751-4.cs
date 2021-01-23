    public partial class Form1 : Form {
       public Form1(){
         InitializeComponent();
         //do this if you want to register the Load event handler using code
         Load += Form1_Load;
       }
       FlowLayoutPanel panel = new FlowLayoutPanel();
       private void InitPanel(){
         panel.Size = new Size(600, 150);
         panel.Location = new Point(50, 50);
         panel.FlowDirection = FlowDirection.LeftToRight;
         panel.AutoScroll = true;
         panel.WrapContents = false;
         Controls.Add(panel);
       }
       //Load event handler
       private void Form1_Load(object sender, EventArgs e){
         InitPanel();
         panel.SuspendLayout();
         string cmdText = "SELECT (FirstName + ' ' + MiddleName + ' ' + LastName) as FullName, " +
                     "imgPath as ImagePath FROM TableVote WHERE Position='President'";
         using(SqlCommand com = new SqlCommand(cmdText,sc)){
           if(sc.State != ConnectionState.Open) sc.Open();
           SqlDataReader reader = com.ExecuteReader();       
           while(reader.Read()){
             AddRadioButton(reader.GetString(0), reader.GetString(1));
           }
           reader.Close();
           sc.Close();
           panel.ResumeLayout(true);
         }
       }
       private void AddRadioButton(string fullName, string imagePath){
         RadioButton radio = new RadioButton {Text = fullName, Parent = panel};
         radio.Image = new Bitmap(Image.FromFile(imagePath),75,75);
         radio.TextImageRelation = TextImageRelation.ImageAboveText;       
       }
    }
