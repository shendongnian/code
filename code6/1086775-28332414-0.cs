    public IHttpActionResult GetProduct(int id)
    {
        var product = products.Where(p => p.Id == id).ToList();
        if (product == null) {
            return NotFound();
        }
        return Ok(product);
    }
