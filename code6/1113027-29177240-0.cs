        /*--------------------------------------------------------------------------------*/
		// Class: CylindericalDelegate
		/*--------------------------------------------------------------------------------*/
		public class CylindericalDelegate : CarouselViewDelegate
		{
			
			/*--------------------------------------------------------------------------------*/
			// Constructors
			/*--------------------------------------------------------------------------------*/
			public CylindericalDelegate()
			{
			}
				
			/*--------------------------------------------------------------------------------*/
			// CylindericalDelegate Implementation
			/*--------------------------------------------------------------------------------*/
						
			public override nfloat ValueForOption(CarouselView carousel, CarouselOption option, nfloat aValue)
			{
				if (option == CarouselOption.Spacing)
				{
					return aValue * 1.1f;
				}
				if (option == CarouselOption.Wrap)
				{
					return 1.0f;
				}
				return aValue;
			}
			/*--------------------------------------------------------------------------------*/
						
		}
	
		/*--------------------------------------------------------------------------------*/
