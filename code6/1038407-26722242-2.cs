    private static string GetEmailBody(PDI bo)
            {
                
                StringBuilder builder = new StringBuilder();
               
                builder.Append("Full Houlse?: ");
                builder.Append(CommonUtilities.GetYESNOfromBOOL(bo.FullHoulse));
                builder.AppendLine();
                builder.Append("Any on call?: ");
                builder.Append(CommonUtilities.GetYESNOfromBOOL(bo.Anyoncall));
                builder.AppendLine();
                builder.Append("Phone Number?: ");
                builder.Append(CommonUtilities.GetYESNOfromBOOL(bo.PhoneNumber));
                builder.AppendLine();
                builder.Append("Email Address?: ");
                builder.Append(CommonUtilities.GetYESNOfromBOOL(bo.EmailAddress));
                builder.AppendLine();
                
                          
                return builder.ToString();
            }
