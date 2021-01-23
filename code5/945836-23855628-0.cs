	public class Doctor
	{
		public virtual int Id { get; set; }
		public virtual string Fullname { get; set; }
		public virtual ICollection<Specialty> SelectedSpecialities { get; set; }
		public virtual ICollection<Specialty> AllSpecialities { get; set; }
		public virtual ICollection<int> PostedSpecialities { get; set; }
	}
	public class Specialty
	{
		public virtual int Id { get; set; }
		public virtual string Title { get; set; }
		public virtual ICollection<Doctor> Doctors { get; set; }
	}
    public ActionResult Add(Doctor m)
    {
        if (ModelState.IsValid)
        {
            context.Entry(m).State = System.Data.Entity.EntityState.Modified;
            m.SelectedSpecialities.Clear();
            // the line below returns a List<Specialty> of selected pecialties
            foreach(var speciality in context.Specialties.Where(x => x.Id == 1))
            {
				m.SelectedSpecialities.Add(speciality);
            }
            context.SaveChanges();
        }
        return View();
    }
