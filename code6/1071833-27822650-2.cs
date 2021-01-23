    public TestMeViewModelTests {
        public when_adding_a_warehouse_then_should_call_service_AddNewWarehouse_given_WarehouseModel {
            //Arrange
            var warehouseViewModel = new WarehouseViewModel { id=1 };
    
            var service = new Mock<IService>();
    
            var interfaceViewModel = new TestMeViewModel(service.Object);
    
            //Act
            interfaceViewModel.AddWarehouseCommand(warehouseViewModel);
    
            //Assert
            service.Verify(s=>s.AddNewWarehouse(wareHouseViewModel), Times.Once);
        }
    }
