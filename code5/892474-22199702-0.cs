    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Drawing;
    using System.Web.UI.DataVisualization.Charting;
    using System.Text;
    using System.Xml;
    
    namespace MyMvcApplication
    {
        public class Theme
        {
            public static string GetTheme()
            {
                ChartArea ca = new System.Web.UI.DataVisualization.Charting.ChartArea("Default");
                var chart = new System.Web.UI.DataVisualization.Charting.Chart();
                chart.BackColor = Color.Azure;
                chart.BackGradientStyle = GradientStyle.TopBottom;
                chart.BackSecondaryColor = Color.White;
                chart.BorderColor = Color.FromArgb(26, 59, 105);
                chart.BorderlineDashStyle = ChartDashStyle.Solid;
                chart.BorderWidth = 2;
                chart.Palette = ChartColorPalette.None;
                chart.PaletteCustomColors = new Color[] { Color.Lime, Color.Red, 
            Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple,
             Color.Black };
                chart.ChartAreas.Add(new ChartArea("Default")
                {
                    BackColor = Color.FromArgb(64, 165, 191, 228),
                    BackGradientStyle = GradientStyle.TopBottom,
                    BackSecondaryColor = Color.White,
                    BorderColor = Color.FromArgb(64, 64, 64, 64),
                    BorderDashStyle = ChartDashStyle.Solid,
                    ShadowColor = Color.Transparent,
                    Area3DStyle = new ChartArea3DStyle()
                    {
                        LightStyle = LightStyle.Simplistic,
                        Enable3D = true,
                        Inclination = 5,
                        IsClustered = true,
                        IsRightAngleAxes = true,
                        Perspective = 5,
                        Rotation = 0,
                        WallWidth = 0
                    }
                });
                chart.Legends.Add(new Legend("All")
                    {
                        BackColor = Color.Transparent,
                        Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold,
                        GraphicsUnit.Point),
                        IsTextAutoFit = false
                    }
                    );
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
    
                var cs = chart.Serializer;
                cs.IsTemplateMode = true;
                //cs.Content = SerializationContents.Appearance;
                cs.Format = SerializationFormat.Xml;
                var sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter xw = XmlWriter.Create(sb, settings))
                {
                    cs.Save(xw);
                }
                string theme = sb.ToString();
                return theme;
            }
        }
    }
