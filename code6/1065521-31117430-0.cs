      public void MethodName(IAnimal animal)
        {
            dynamic actualObject = animal;
            bus.Publish(actualObject);
        }
