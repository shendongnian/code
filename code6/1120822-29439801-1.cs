    public async Task<IHttpActionResult> GetMemberIDByName(string MemberStr)
    {
        var member = await db.Members.Where(x => x.UserName == MemberStr).ToListAsync();
        if (member == null)
        {
            return NotFound();
        }
        return Ok(member[0].MemberID);
    }
