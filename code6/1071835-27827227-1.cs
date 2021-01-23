    public class ViewModelTest {
       public void when_adding_warehouse() {
           //Arrange
            var aWarehouse = new WarehouseViewModel { id=1 };
    
            var serviceFactory = new Mock<IServiceFactory>().Object);
            var service = new Mock<IService>();
            serviceFactory.Setup(factory => factory.Create()).Returns(service.Object);
      
            var viewModel = new ViewModel(serviceFactory.Object);
    
            //Act
            viewModel.AddWarehouseCommand(warehouseViewModel);
    
            //Assert
            service.Verify(s=>s.AddNewWarehouse(aWarehouse), Times.Once);
       }
    }
