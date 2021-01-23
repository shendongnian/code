      public static string test()
            {
                string mail = "########";
                bool? answer;
                Exception ex;
        try
        {
                answer = IsValidEmailDomain(mail);
        }
        catch(Exception e)
        {
            ex = e;
        }
                if (answer)
                {
                    return mail;
                }
                else
                {
                    // here you can check to see if the answer is null or if you actually got an exception
                }
            }
