       SmtpClient smtp = new SmtpClient(objBO.SmtpDomain);
            try{
            smtp.Send(message);
            }
            catch{
            }
            finally{
             //deletes the file.
            }
