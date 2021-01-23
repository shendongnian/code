    <EntityType Name="CustomerImage">
        <Key>
            <PropertyRef Name="CustomerId"/>
            <PropertyRef Name="ImageId"/>
        </Key>
        <Property Name="CustomerId" Type="Edm.Int32" Nullable="false"/>
        <Property Name="ImageId" Type="Edm.Int32" Nullable="false"/>
        <Property Name="LastUpdated" Type="Edm.DateTime"/>
        <NavigationProperty Name="Customer" Relationship="EasyBizy.Entities.Models.EasyBizy_Entities_Models_CustomerImage_Customer_EasyBizy_Entities_Models_Customer_CustomerPartner" ToRole="Customer" FromRole="CustomerPartner"/>
        <NavigationProperty Name="Image" Relationship="EasyBizy.Entities.Models.EasyBizy_Entities_Models_CustomerImage_Image_EasyBizy_Entities_Models_Image_ImagePartner" ToRole="Image" FromRole="ImagePartner"/>
    </EntityType>
