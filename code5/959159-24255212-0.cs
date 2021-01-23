    myReader = myCommand.ExecuteReader();
    var message = new StringBuilder();
            while (myReader.Read())
            {
                string datetype = (myReader["Expiry_Date"].ToString());
                DateTime dateformat = DateTime.Parse(datetype); 
                if(dateformat.Date <= calDate3b && dateformat.Date>=timenow)
                {
                    message.AppendLine(myReader["Number"].ToString());
                    message.AppendLine(myReader["Name"].ToString());
                    message.AppendLine(myReader["Number_Yolo"].ToString());
                    message.AppendLine(myReader["Date"].ToString());
					message.AppendLine();                    
                }
            }
    Console.WriteLine(message.ToString());
    mail.Body = message.ToString();
