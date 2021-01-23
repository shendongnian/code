        public IEnumerable<Animal> GetAnimalsWithFoodsInDen(int denId)
        {
            var den = context.Dens.FirstOrDefault(x => x.DenID == denId);
            IEnumerable<Animal> animals = new Animal[0];
            if (den != null)
            {
                var foods = den.FoodList;
                if (foods != null)
                {
                    foreach (var food in foods)
                    {
                        animals.Add(food.AnimalList.ToList());
                    }
                }
            }
            return animals;
        }
