      StringBuilder emailMessage = new StringBuilder();
                        emailMessage.AppendLine("Here is the Verification Code.");
                       // emailMessage.Append(Environment.NewLine);
                        emailMessage.AppendLine("UserName: " + UsernameTextBox.Text);
                        emailMessage.AppendLine();
                        emailMessage.AppendLine("Code:  " + newCode);  
