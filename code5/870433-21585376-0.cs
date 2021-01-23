	private class OfferWithCompanyModelCustomization: ICustomization
	{
		public void Customize(IFixture fixture)
		{
			fixture.Customizations.Add(new FilteringSpecimenBuilder(new Postprocessor(
				new ModelSpecimenBuilder(), new FillModelPropertiesCommand()), new ExactTypeSpecification(typeof(Offer))));
		}
		private class FillModelPropertiesCommand : ISpecimenCommand
		{
			public void Execute(object specimen, ISpecimenContext context)
			{
				var offer = specimen as Offer;
				offer.CompanyHistory = (CompanyHistory)context.Resolve(typeof(CompanyHistory));
			}
		}
	}
