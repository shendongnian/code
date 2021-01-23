    private void button1_Click(object sender, EventArgs e)
            {
                string Name;
                string Surname;
                int Maths;
                int Science;
                int IT;
                float Average;
    
    
                Name = edtName.Text;
                Surname = edtSurname.Text;
                Maths = int.Parse(edtMaths.Text);
                Science = int.Parse(edtScience.Text);
                IT = int.Parse(edtIT.Text);
                Average = ((((float)Maths/150.0)*100)+(((float)IT/150.0)*100)+(((float)Science/150.0)*100))/3;
    
                if (Average >= 75)
                {
                    lblOutput.Text += "You shall recieve a bursary!";
                } 
