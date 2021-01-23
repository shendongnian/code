    public class Person
    {
        public virtual Guid Id { get; protected set; }
        public virtual String Name { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public Person()
        {
            PersonAddresses = new List<PersonAddress>();
        }
        public virtual void AddPersonAddress(PersonAddress personAddress)
        {
            if (PersonAddresses.Contains(personAddress))
                return;
            PersonAddresses.Add(personAddress);
            personAddress.Person = this;
        }
    }
    public class PersonMap : ClassMapping<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.GuidComb);
            });
            Property(x => x.Name);
            Bag(x => x.PersonAddresses, map =>
            {
                map.Table("PersonAddress");
                map.Key(k =>
                {
                    k.Column(col => col.Name("PersonId"));
                });
                map.Cascade(Cascade.All);
            },
            action => action.OneToMany());
        }
    }
    public class Address
    {
        public virtual Guid Id { get; protected set; }
        public virtual String AddressLine1 { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public Address()
        {
            PersonAddresses = new List<PersonAddress>();
        }
    }
    public class AddressMap : ClassMapping<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.GuidComb);
            });
            Property(x => x.AddressLine1);
            Bag(x => x.PersonAddresses, map =>
            {
                map.Inverse(true);
                map.Table("PersonAddress");
                map.Key(k =>
                {
                    k.Column(col => col.Name("AddressId"));
                });
                //map.Cascade(Cascade.All);
            },
            action => action.OneToMany());
        }
    }
    public class PersonAddress
    {
        public virtual Guid Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Address Address { get; set; }
        public virtual String Description { get; set; }
    }
    public class PersonAddressMap : ClassMapping<PersonAddress>
    {
        public PersonAddressMap()
        {
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.GuidComb);
            });
            ManyToOne(x => x.Person, map =>
            {
                map.Column("PersonId");
                map.NotNullable(false);
            });
            ManyToOne(x => x.Address, map =>
            {
                map.Column("AddressId");
                map.NotNullable(false);
                map.Cascade(Cascade.All);
            });
            Property(x => x.Description);
        }
    }
