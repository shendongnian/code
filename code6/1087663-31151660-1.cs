      public IHttpActionResult Post(Student student)
      {
            student.Teacher = this.db.Teacher.FirstOrDefault(i => i.TeacherId == student.TeacherId);
            if (student.Teacher != null)
            {
                this.ModelState.Remove("student.Teacher");
            }
            
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
      }
