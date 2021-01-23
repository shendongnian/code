        public ActionResult AccountsExportCSV()
        {
            MemoryStream output = new MemoryStream();
            StreamWriter writer = new StreamWriter(output);
            load_repo();
            var accounts = _repo.GetAllAccounts();
            writer.Write("Email");
            writer.Write(",");
            writer.Write("Full Name");
            writer.Write(",");
            writer.Write("Phone");
            writer.Write(",");
            writer.Write("Points");
            writer.Write(",");
            writer.Write("Date Added");
            writer.Write(",");
            writer.Write("Last Sync");
            writer.Write(",");
            writer.Write("User Type");
            writer.WriteLine();
            int userType = 0;
            foreach (Account account in accounts)
            {
                writer.Write(account.Email);
                writer.Write(",");
                writer.Write(account.FullName);
                writer.Write(",");
                writer.Write(account.Phone);
                writer.Write(",");
                writer.Write(account.Points);
                writer.Write(",");
                writer.Write(account.AddDate);
                writer.Write(",");
                writer.Write(account.LastDate);
                writer.Write(",");
                userType = Convert.ToInt32(account.UserType);
                switch (userType)
                {
                    case 0:
                        writer.Write("Unknown");
                        break;
                    case 1:
                        writer.Write("User");
                        break;
                    case 10:
                        writer.Write("Support");
                        break;
                    case 20:
                        writer.Write("Manager");
                        break;
                    case 30:
                        writer.Write("Admin");
                        break;
                    case 40:
                        writer.Write("Developer");
                        break;
                }
                writer.WriteLine();
            }
            writer.Flush();
            output.Position = 0;
            return File(output, "text/comma-seperated-values", "accounts.csv");
        }
