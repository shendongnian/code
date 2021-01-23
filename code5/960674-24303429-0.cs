        private void frmMain_Load(object sender, EventArgs e)
        { 
             AddHandleNumericUpdownLeave(this);
        }
        public static void AddHandleNumericUpdownLeave(Control theContrl)
        {
            if (theContrl.Controls != null && theContrl.Controls.Count > 0)
            {
                foreach (Control cControl in theContrl.Controls)
                {
                    AddHandleNumericUpdownLeave(cControl);
                }
            }
            else
            {
                NumericUpDown nudCtrl = theContrl as NumericUpDown;
                if (nudCtrl != null)
                {
                    nudCtrl.Leave += (object senderT, EventArgs eT) =>
                    {
                        var tmpCtrl = senderT as NumericUpDown;
                        if (tmpCtrl != null)
                        {
                            if (tmpCtrl.Value < 1 || tmpCtrl.Value > 6)
                            {
                                tmpCtrl.BackColor = Color.Red;
                            }
                            else
                            {
                                tmpCtrl.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
        }
