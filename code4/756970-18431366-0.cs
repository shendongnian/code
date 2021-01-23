    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    
    namespace dynamics_test
    {
        class CustomOne
        {
            public string NotInCustomTwo { get; set; }
            public DateTime DateAdded { get; set; }
        }
    
        class CustomTwo
        {
            public string NotInCustomOne { get; set; }
            public DateTime DateAdded { get; set; }
        }
    
    
        [TestFixture]
        public class TestDynamics
        {
            private List<CustomOne> _customOnes;
            private List<CustomTwo> _customTwos;
    
            [SetUp]
            public void Setup()
            {
                this._customOnes = new List<CustomOne>()
                    {
                        new CustomOne {DateAdded = DateTime.Now.AddDays(1), NotInCustomTwo = "some value"},
                        new CustomOne {DateAdded = DateTime.Now, NotInCustomTwo = "some value"}
                    };
                this._customTwos = new List<CustomTwo>()
                    {
                        new CustomTwo {DateAdded = DateTime.Now.AddDays(1), NotInCustomOne = "some value"},
                        new CustomTwo {DateAdded = DateTime.Now, NotInCustomOne = "some value"}
                    };
            }
    
            [Test]
            public void DynamicsAllowBadThingsMkay()
            {
                var dynamics = _customOnes.Cast<dynamic>().ToList();
                dynamics.AddRange(_customTwos);
                foreach (var thing in dynamics)
                {
                    Console.WriteLine(thing.DateAdded);
                }
            }
        }
    }
