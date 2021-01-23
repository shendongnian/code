            con.Open();
            cmd = new SqlCommand("SELECT   tblAddResult.* FROM  tblAddResult", con);
            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//this will close the DataReader along with Connection close.
    
            while (sdr.Read())
            {
    
                String subject = sdr.GetString(2);
                int january = sdr.GetInt32(3);
                int february = sdr.GetInt32(4);
                int march = sdr.GetInt32(5);
                int average = (january + february + march) / 3;
                int average40= average*40/(100);
                int marks = sdr.GetInt32(6);
                int marks50 = marks * 50 / 100;
                int WorkingDay = sdr.GetInt32(7);
                int Attandence = sdr.GetInt32(8);
                int Attendence10 = Attandence * 10 / 100;
                int totalMarks = average40 + marks50 + Attendence10;
                string grade = "" ;
                if (totalMarks < 51) { grade = "C"; }
                else if (totalMarks < 61) { grade = "B"; }
                else if (totalMarks < 71) { grade = "A-"; }
                else if (totalMarks < 81) { grade = "A"; }
                else if (totalMarks < 91) { grade = "A+"; }
                else if (totalMarks <= 100) { grade = "A++"; }
                
                cmd = new SqlCommand("INSERT INTO tblResult (Subject, [Full Marks], January, February, March, [Average Class Perfomance], [Earned Marks], [Working Day], Attendence, [Cls Attendence(40%)], [Exam Perfomance(50%)], [Attendence(10%)], [Marks(%)], Grade)VALUES  ('"+subject+"','"+"100"+"','"+january+"','"+february+"','"+march+"','"+average+"','"+marks+"','"+WorkingDay+"','"+Attandence+"','"+average40+"','"+marks50+"','"+Attendence10+"','"+totalMarks+"','"+grade+"')",con);
                cmd.ExecuteNonQuery();           
    
            }
            con.Close();
            MessageBox.Show("Successfull!");
