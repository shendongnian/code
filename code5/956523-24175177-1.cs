    using System;
    using System.IO;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using AutoMapper;
    namespace SO24174411
    {
        class Program
        {
            static void Main()
            {
                AlbumSerializationContainer example1 = new AlbumSerializationContainer
                {
                    CoverImgIndx = 2,
                    Description = "Some explanation.",
                    Images = new List<ImageSerializationContainer>
                    {
                        new ImageSerializationContainer {FilePath = @"C:\Images\file1.jpg", Index = 0},
                        new ImageSerializationContainer {FilePath = @"C:\Images\file2.png", Index = 1},
                        new ImageSerializationContainer {FilePath = @"C:\Images\file3.jpg", Index = 2},
                        new ImageSerializationContainer {FilePath = @"C:\Images\file4.bmp", Index = 3}
                    },
                    Title = "Album Title"
                };
                Console.WriteLine("Example 1");
                Console.WriteLine(Serialize(example1));
                Album album = new Album
                {
                    CoverImgIndx = 2,
                    Description = "Some explanation.",
                    Images = new ImageList(),
                    Title = "Album Title"
                };
                SetImages(album.Images, new[]
                {
                    @"C:\Images\file1.jpg", 
                    @"C:\Images\file1.jpg", 
                    @"C:\Images\file2.png", 
                    @"C:\Images\file4.bmp"
                });
                var example2 = PerformMapping(album);
                Console.WriteLine("Example 2");
                Console.WriteLine(Serialize(example2));
            }
            private static AlbumSerializationContainer PerformMapping(Album album)
            {
                Mapper.CreateMap<Album, AlbumSerializationContainer>();
                Mapper.CreateMap<ImageList, List<ImageSerializationContainer>>().ConvertUsing<ImageListconverter>();
                AlbumSerializationContainer example2 = Mapper.Map<AlbumSerializationContainer>(album);
                return example2;
            }
            public class ImageListconverter : TypeConverter<ImageList, List<ImageSerializationContainer>>
            {
                protected override List<ImageSerializationContainer> ConvertCore(ImageList source)
                {
                    if (source == null)
                    {
                        return null;
                    }
                    List<ImageSerializationContainer> result = new List<ImageSerializationContainer>();
                    for (int i = 0; i < source.Images.Count; i++)
                    {
                        result.Add(new ImageSerializationContainer { FilePath = ((string[])source.Tag)[i], Index = i });
                    }
                    return result;
                }
            }
            public static string Serialize(AlbumSerializationContainer a)
            {
                XmlSerializer ser = new XmlSerializer(typeof(AlbumSerializationContainer));
                StringWriter sw = new StringWriter();
                ser.Serialize(sw, a);
                return sw.ToString();
            }
            public static void SetImages(ImageList l, string[] names)
            {
                l.Tag = names;
                for(int i=0;i<names.Length;i++)
                {
                    // Aparently you can read names[i] file here if you want
                    l.Images.Add(new Bitmap(1, 1));
                }
            }
        }
        public class Album
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int CoverImgIndx { get; set; }
            public ImageList Images { get; set; }
            
        }
        [XmlType(TypeName = "Image")]
        public class ImageSerializationContainer
        {
            [XmlElement(ElementName = "indx")]
            public int Index { get; set; }
            [XmlElement(ElementName = "filepath")]
            public string FilePath { get; set; }
        }
        [XmlType(TypeName = "Album")]
        public class AlbumSerializationContainer
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int CoverImgIndx { get; set; }
            public List<ImageSerializationContainer> Images { get; set; }
        }
    }
