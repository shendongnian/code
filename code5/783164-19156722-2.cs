	public class SortableCarIndex : AbstractIndexCreationTask<Car, SortableCar>
	{
		public SortableCarIndex()
		{
			Map = cars =>
				    from car in cars
				    select
					    new SortableCar
						    {
							    Car = car,
							    ClassificationId =
								    Array.IndexOf(new[]{
										"Compact",
										"Hatch",
										"Convertible",
										"Muscle"
									}, car.Classification)
						    };
		}
	}
	public class SortableCar
	{
		public Car Car { get; set; }
		public int ClassificationId { get; set; }
	}
