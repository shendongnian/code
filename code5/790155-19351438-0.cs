    public List<Userlist> Friendlist(int id)
        { 
            int i = 0;
            FyfDataContext db = new FyfDataContext();
            List<Friend> friends = db.Friends.Where(P => P.PK_ID == id).ToList();
            List<Userlist> userlist = new List<Userlist>();
            while (i < friends.Count)
            {
                Userlist u = new Userlist();
                u.id = Convert.ToInt32(friends[i].FK_ID);
                userlist.Add(u);
                i++;
            }
            return userlist;
        }
