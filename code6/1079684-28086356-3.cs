    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("Myself")]
        public virtual ICollection<WorkRelationship> WorkRelationships { get; set; }
        public void AddWorkRelationship(Person colleague)
        {
            if (WorkRelationships == null)
            {
                WorkRelationships = new List<WorkRelationship>();
            }
            WorkRelationships.Add(new WorkRelationship { Myself = this, Colleague = colleague });
        }
    }
