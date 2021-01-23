    // Define the taxonomic levels here. Each level (except the first) references its next-higher taxonomic level in a type constraint
    interface Material { }
    interface Object<TMaterial> where TMaterial : Material { }
    // Define the items in the highest taxonomic level (materials)
    interface Wood : Material { }
    interface Metal : Material { }
    // Define the items in the 2nd taxonomic level (objects), implementing the appropriate interfaces to specify what the valid top-level taxonomies it can fall under.
    interface Crate : Object<Wood>, Object<Metal> { }
    interface Bar : Object<Metal> { }
    interface Box : Object<Wood> { }
    // Define an item class with type constraints to ensure the taxonomy is correct
    abstract class Item<TMaterial, TObject>
        where TMaterial : Material
        where TObject : Object<TMaterial>
    {
    }
