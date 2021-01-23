     var sampleViewModelList= new List<SampleViewModel>() {
        				new SampleViewModel() {Id=1, Name="A"},
        				new SampleViewModel() {Id=2, Name="B"},
        				new SampleViewModel() {Id=3, Name="C"}
        			};
        			
     ViewBag.SomeList = new SelectList(sampleViewModelList, "Id", "Name",sampleViewModelList.First(x => x.Id == 2).Id); 
