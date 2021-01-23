    public class CarClassData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new Car
                    {
                      Id=1,
                      Price=36000000,
                      Manufacturer = new Manufacturer
                      {
                        Country="country",
                        Name="name"
                      }
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
