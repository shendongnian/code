    public TestMeViewModelTests {
        public when adding a warehouse then should call service.AddNewWarehouse given WarehouseModel {
            //Arrange
            var warehouseViewModel = new WarehouseViewModel { id=1 };
    
            var service = new Mock<IService>();
    
            var interfaceViewModel = new TestMeViewModel(service.Object);
    
            //Act
            interfaceViewModel.AddWarehouseCommand(warehouseViewModel);
    
            //Assert
            service.Verify(s=>s.AddNewWarehouse, Times.Once);
        }
    }
