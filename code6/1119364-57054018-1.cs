        private void RTB_TextChanged(object sender, EventArgs e)
        {
            int selStart = RTB.SelectionStart;
            int selLenght = RTB.SelectionLength;
            auxRTB.Text = RTB.Text;
            RTB.TextChanged -= RTB_TextChanged;
            RTB.Rtf = string.Copy(auxRTB.Rtf);
            RTB.TextChanged += RTB_TextChanged;
            try
            {
                RTB.SelectionStart = selStart;
                RTB.SelectionLength = selLenght;
            }
            catch (Exception) { }
        }
