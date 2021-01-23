    public class MyAdapter...
    {
        private IEnumerable<SelectedFeature> selectedFeatures;
        public MyAdapter()
        {
            ...your code...
            using (VehicleFeaturesDB vfdb = new VehicleFeaturesDB())
            {
                selectedfeatures = vfdb.GetSelectedFeatures(Selector.vehicleId);
            }
        }
        
        public override View GetView(int pos, View convertView, ViewGroup parent)
        {
            ...your code...
            CheckBox.Checked = selectedFeatures.Any(sf => sf.FeatureID == feature.FeatureID);
        }
