    private Dictionary<MyEnumType, IList<MyViewModel.MySubViewModel>> GetSubsDict()
    {
    	return new Dictionary<MyEnumType, IList<MyViewModel.MySubViewModel>>() 
    				{
    					{
    						MyEnumType.MySubViewModel, 
    						new List<MyViewModel.MySubViewModel>
    						{
    							new MyViewModel.MySubViewModel
    							{
    								Name = "Foo-Bar"
    							}
    						}
    					}
    				}
    }
