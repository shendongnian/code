        public string variable0, variable1, variable2, variable3, variable4, variable5;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                //pretending my variable names are variable1, variable2.. ("variable" is NOT an array! just the "assign" variable)
                System.Reflection.FieldInfo info = this.GetType().GetField("variable" + i.ToString());
                // replace "testing" with the value you want e.g. assign[i]
                info.SetValue(this, "testing");
            }
            
            // Do something with your new values
        }
