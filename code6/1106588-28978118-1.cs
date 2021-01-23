    public void UpdateAllowance(Allowance allowance, string userId)
    {
        allowance.UpdatedDate = DateTime.Now;
        allowance.UpdatedBy = userId;
        db.Entry(allowance).State = EntityState.Modified;
    }
    public void Save()
    {
        db.SaveChanges();
    }
