		var carsOrderedByClassification =
			session.Query<SortableCar, SortableCarIndex>()
					.OrderBy(x => x.ClassificationId)
					.AsProjection<Car>()
					.ToList();
