    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    namespace ConsoleApp
    {
        class Person
        {
            private string _name;
            private string _jobTitle;
            // For consistency, I would recommend creating a
            // private backing field for Email, too. But it's not
            // strictly necessary.
            public Person(string name, string email, string title)
            {
                // Are these pre-conditions strict enough??
                // Maybe they are, but just asking.
                Contract.Requires(name != null);
                Contract.Requires(title != null);
                _name = name;
                _jobTitle = title;
                Email = email;
            }
            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(_name != null);
                Contract.Invariant(_jobTitle != null);
            }
            public string Name
            {
                get
                {
                    Contract.Ensures(Contract.Result<string>() != null);
                    return _name;
                }
                set
                {
                    Contract.Requires(value != null);
                    _name = value;
                }
            }
            public string JobTitle
            {
                get
                {
                    Contract.Ensures(Contract.Result<string>() != null);
                    return _jobTitle;
                }
                set
                {
                    Contract.Requires(value != null);
                    _jobTitle = value;
                }
            }
            public string Email { get; set; }
        }
