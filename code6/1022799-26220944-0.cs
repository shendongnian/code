    [HttpDelete]
    [Route("Remove/{id}")]
    public void Remove(int id) {
        _repo.Remove(id);
    }
