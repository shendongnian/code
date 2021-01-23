        public IEnumerable<Animal> GetAnimalsWithFoodsInDen(int denId)
        {
            var den = context.Dens.FirstOrDefault(x => x.DenID == denId);
            var animals = new List<Animal>();
            if (den != null)
            {
                var foods = den.FoodList;
                if (foods != null)
                {
                    foreach (var food in foods)
                    {
                        animals.Union(food.AnimalList);
                    }
                }
            }
            return animals;
        }
