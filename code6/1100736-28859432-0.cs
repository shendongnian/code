    public class InventoryViewModel
      : MvxViewModel
    {
        public async void Init(Guid ID)
        {
            await MPS_Mobile_Driver.Droid.DataModel.ShipmentDataSource.GetShipmentInventory(ID);
            ShipmentInventory = ShipmentDataSource.CurrInventory;
            Shipment = await MPS_Mobile_Driver.Droid.DataModel.ShipmentDataSource.GetShipment((int)ShipmentInventory.idno, (short)ShipmentInventory.idsub);
        }
        private Shipment _Shipment;
        public Shipment Shipment
        {
            get { return _Shipment; }
            set { _Shipment = value; RaisePropertyChanged(() => Shipment); }
        }
        private ShipmentInventory _ShipmentInventory;
        public ShipmentInventory ShipmentInventory
        {
            get { return _ShipmentInventory; }
            set { _ShipmentInventory = value; RaisePropertyChanged(() => ShipmentInventory); }
        }
    }
