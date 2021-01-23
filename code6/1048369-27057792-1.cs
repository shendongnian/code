    public class OM_Vendor {
        ...
        public static implicit Operator OM_Vendor(Vendor vendor){
            return new OM_Vendor {
                Id = vendor.Id;
                Name = vendor.Name;
                ApiUrl = vendor.ApiUrl;
        }
    }
    OM_Vendor om_Vendor = this.objEntity.vendors.Where(
    ...
    List<OM_Vendor> vendors = this.objEntity.vendors.Where(
    ...
