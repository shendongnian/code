    @using Jdmxchange_V3.Models
    @if (Model is BulletinViewModels.BulletinDetailsViewModel)
    {
        var bdvm = Model as BulletinViewModels.BulletinDetailsViewModel;
        // do things specific to this type
    }
    else if(Model is EventDetailsViewModel)
    {
        var edvm = Model as EventDetailsViewModel;
        // do things specific to this type
    }
