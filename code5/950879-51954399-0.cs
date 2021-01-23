        using System;
        using System.Linq;
        using System.Reflection;
        using System.ComponentModel.DataAnnotations;
        namespace PruebaAtributos
        {
            // Podemos ver la definición de 'MetaDataType' en:
            // https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/MetadataTypeAttribute.cs,fb9a5881152a1584,references
            [MetadataType(typeof(ProgramMetadata))]
            partial class Program
            {
                // Campos de la clase
                public int Id { get; set; }
                public string Nombre { get; set; }
                public string Puesto { get; set; }
                static void Main(string[] args)
                {
                    Type t = typeof(Program);
                    // Atributos de la clase
                    Console.WriteLine("--- Atributos de clase: ");
                    Attribute[] attrs = Attribute.GetCustomAttributes(t);
                    foreach (Attribute at in attrs)
                    {
                        Console.WriteLine(at.GetType().Name);
                        if (at is MetadataTypeAttribute mdt)
                        {
                            // Nos interesa la información que contiene 'MetadataType'
                            Console.WriteLine($"--- Campos de {mdt.GetType().Name}:");
                            // Obtenemos las propiedades de la clase asociada con metadata type
                            var fields = mdt.MetadataClassType.GetFields();
                            foreach (FieldInfo fi in fields)
                            {
                                // Y mostramos los atributos asociados a cada uno de sus campos
                                var cas = fi.GetCustomAttributes(); // ca = Custom Attributes
                                Console.WriteLine($"   {fi.Name}.");
                                Console.WriteLine($"      attributos: {string.Join(", ", cas.Select(a => a.GetType().Name))}");
                                // Ahora consultamos la propiedad que deseamos de cada atributo conocido:
                                // Para consultar un attributo específico:
                                //DisplayAttribute da = (DisplayAttribute)ca.FirstOrDefault(a => a.GetType() == typeof(DisplayAttribute));
                                //if (da != null)
                                //{
                                //    Console.WriteLine($"   {da.GetType().Name}: {da.Name}");
                                //}
                                string desc;
                                foreach (var fa in cas) // fa = Field Attribute
                                {
                                    if (fa is ExportarAttribute exp)
                                    {
                                        // Conocemos las propiedades específicas de este 
                                        desc = $"{exp.GetType().Name}.exportar: {exp.exportar}";
                                    }
                                    else if (fa is MostrarAUsuario mau)
                                    {
                                        desc = $"{mau.GetType().Name}.mostrar: {mau.mostrar}";
                                    }
                                    else if (fa is DisplayAttribute da)
                                    {
                                        desc = $"{da.GetType().Name}.Name: {da.Name}";
                                    }
                                    else
                                    {
                                        desc = fa.GetType().Name;
                                    }
                                    Console.WriteLine($"      {desc}");
                                }
                            }
                        }
                    }
                }
            }
            // Attributos personalizados
            [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
            class MostrarAUsuario : Attribute
            {
                public readonly bool mostrar;
                public MostrarAUsuario(bool mostrar = true)
                {
                    this.mostrar = mostrar;
                }
            };
            class ExportarAttribute : Attribute
            {
                public readonly bool exportar;
                public ExportarAttribute(bool exportar = true)
                {
                    this.exportar = exportar;
                }
            }
            public class ProgramMetadata
            {
                // Display pertenece a MVC: System.ComponentModel.DataAnnotations
                [Display(Name = "Identificador"), MostrarAUsuario(false), Exportar(false), Phone]
                public int Id;
                [Display(Name = "Nombre completo"), MostrarAUsuario]
                public int Nombre;
                [Display(Name = "Puesto de trabajo"), Exportar]
                public int Puesto;
            }
        }
