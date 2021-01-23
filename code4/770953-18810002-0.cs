    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using D = DocumentFormat.OpenXml.Drawing;
    D.ShapeTypeValues shapeType; // Any of the built-in shapes (ellipse, rectangle, etc)
    string rgbColorHex; // Hexadecimal RGB color code to fill the shape.
    long x; // Represents the shape x position in 1/36000 cm.
    long y; // Represents the shape y position in 1/36000 cm.
    long width; // Shapw width in in 1/36000 cm.
    long heigth;// Shapw heigth in in 1/36000 cm.
