        public void GetNumUpDownValue(object sender, EventArgs e)
        {
            int iname = int.Parse(((NumericUpDown)sender).Name);
            int ivalue = (int)((NumericUpDown)sender).Value;
           // Check if the dictionary already contains the value, if so, update it
           if(waytosave.ContainsKey(iname))
               waytosave[iname] = ivalue;
           else  // otherwise add the key and value
               waytosave.Add(iname, ivalue);
           txtOutputs.Text += "\r\r\n" + "   Node # " + iname + " = " + waytosave[iname].ToString();
        }
