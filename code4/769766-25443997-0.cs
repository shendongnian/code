               string movie="";
               if (checkBox1.Checked == true)
                {
                    movie=movie+checkBox1.Text + ",";
                }
                if (checkBox2.Checked == true)
                {
                    movie=movie+checkBox2.Text + ",";
                }
                if (checkBox3.Checked == true)
                {
                    movie=movie+checkBox3.Text + ",";
                }
                
                if (checkBox4.Checked == true)
                {
                    movie = movie + checkBox4.Text + ",";
                }
                if (checkBox5.Checked == true)
                {
                    movie = movie + checkBox5.Text + ",";
                }
                if (checkBox6.Checked == true)
                {
                    movie = movie + checkBox6.Text + ",";
                }
              row["EnquiryFor"] = movie.ToString();
