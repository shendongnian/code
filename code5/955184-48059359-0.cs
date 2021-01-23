    [HttpPost]
    public async Task<IActionResult> SaveDrawing([FromBody]DrawingModel drawing)
    {
    
    
        try
        {
    
            await Task.Factory.StartNew(() =>
            {
                //Logic
            });
            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest();
        }
    }
