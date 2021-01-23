    public static string messageParser(User user)
        {
            string final = "";
            if (user != null)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                
                var list = user.Message.ToList();
                foreach (var item in user.Message)
                {
                    final += item.notification + "\n\n";
                    Message delete = db.Message.Find(item.ID);
                    db.Message.Remove(delete);
                    db.SaveChanges();
                }
            }
            return final;
            
        }
