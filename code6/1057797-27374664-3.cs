    public async Task<ActionResult> GetResponse(int id)
    {
         //some logic
         await Task.Run(() => { B.Update(id); });
         //some logic
         return View(...);
    }
