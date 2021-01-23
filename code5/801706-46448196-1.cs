    [HttpPost("[action]/{idForDeleteItem}"), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long idForDeleteItem)
    {
        ///delete with param id goes here
    }
