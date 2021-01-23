    [HttpPut]
        [Route("api/MilestonePut/{id}")]
        public void Put(int id, [FromBody]Milestone milestone)
        {
            db.Entry(milestone).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
