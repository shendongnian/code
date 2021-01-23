    #if !bcad
    using Autodesk.AutoCAD.DatabaseServices;
    #else
    using Teigha.DatabaseServices;
    #endif
    using Castle.Core.Logging;
    using System.Collections.Generic;
    
    namespace KojtoCAD.Utilities
    {
        public class MeasurementUnitsConverter
        {
            private ILogger _logger = NullLogger.Instance;
        private readonly Dictionary<UnitsValue, double> _linkBetweenDrawingUnitsAndMilimeters;
        public MeasurementUnitsConverter()
        {
            _linkBetweenDrawingUnitsAndMilimeters = new Dictionary<UnitsValue, double>
                                                        {
                                                            {
                                                                UnitsValue.Angstroms,
                                                                0.0000001
                                                            },
                                                            {
                                                                UnitsValue.Astronomical,
                                                                149600000000000
                                                            },
                                                            {
                                                                UnitsValue.Centimeters, 10
                                                            },
                                                            {
                                                                UnitsValue.Decimeters, 100
                                                            },
                                                            {
                                                                UnitsValue.Dekameters,
                                                                10000
                                                            },
                                                            { UnitsValue.Feet, 304.8 },
                                                            {
                                                                UnitsValue.Gigameters,
                                                                1000000000000
                                                            },
                                                            {
                                                                UnitsValue.Hectometers,
                                                                100000
                                                            },
                                                            { UnitsValue.Inches, 25.4 },
                                                            {
                                                                UnitsValue.Kilometers,
                                                                1000000
                                                            },
                                                            {
                                                                UnitsValue.LightYears,
                                                                9460700000000000000
                                                            },
                                                            { UnitsValue.Meters, 1000 },
                                                            {
                                                                UnitsValue.MicroInches,
                                                                0.0000254
                                                            },
                                                            { UnitsValue.Microns, 0.001 },
                                                            {
                                                                UnitsValue.Miles, 1609344.0
                                                            },
                                                            { UnitsValue.Millimeters, 1 },
                                                            { UnitsValue.Mils, 25400 },
                                                            {
                                                                UnitsValue.Nanometers,
                                                                0.000001
                                                            },
                                                            { UnitsValue.Undefined, 1.0 },
                                                            { UnitsValue.Yards, 914.4 }
                                                        };
            //_linkBetweenDrawingUnitsAndMilimeters.Add(UnitsValue.Parsecs, 30857000000000000000);
        }
        public double GetScaleRatio(UnitsValue sourceUnits, UnitsValue targetUnits)
        {
            if (sourceUnits == UnitsValue.Undefined || targetUnits == UnitsValue.Undefined
                || !_linkBetweenDrawingUnitsAndMilimeters.ContainsKey(sourceUnits)
                || !_linkBetweenDrawingUnitsAndMilimeters.ContainsKey(targetUnits))
            {
                return 1;
            }
            return _linkBetweenDrawingUnitsAndMilimeters[sourceUnits]
                   / _linkBetweenDrawingUnitsAndMilimeters[targetUnits];
        }
    }
    }
