    public List<string> getPhoneLogs2()
    {
        using (var repo = new OCASPhoneCallsRepository(new UnitOfWorkCTS()))
        {
            List<string> phone = repo.AllIncluding(p => p.OCASStaff)
                .Where(y => y.intNIOSHClaimID == null)
                .Select(w => w.vcharDiscussion.Substring(0, 100) + "...")
                .ToList();                  
            return phone;
        }
    }
