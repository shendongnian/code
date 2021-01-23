    using CZEV = CostZoneEffectivityView;    
    ...    
    public class CostZoneEffectivityViewModel : CustomerViewModel, 
             IViewModel, 
             ISQLFilter<CZEV>, 
             IRefresh<CZEV>, 
             ITotal<CZEV>
