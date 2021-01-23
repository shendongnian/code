            var unitOfWork = new UnitOfWork();
            
            unitOfWork.GetRepository<Car>().Add(new Car {Name = "Audi"});
            unitOfWork.GetRepository<Car>().Add(new Car { Name = "BMW" });
            foreach (var car in unitOfWork.GetRepository<Car>().Values)
                Console.WriteLine(car.Name);
