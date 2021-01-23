    // ==========================================
        //   (1) create a simple solid by extrusion
        // ==========================================
        Extrusion createSolid()
        {
          //
          // (1) define a simple rectangular profile
          //
          //  3     2
          //   +---+
          //   |   | d    h = height
          //   +---+
          //  0     1
          //  4  w
          //
          CurveArrArray pProfile = createProfileRectangle();
          //
          // (2) create a sketch plane
          //
          // we need to know the template. If you look at the template (Metric Column.rft) and "Front" view,
          // you will see "Reference Plane" at "Lower Ref. Level". We are going to create an extrusion there.
          // findElement() is a helper function that find an element of the given type and name.  see below.
          //
          ReferencePlane pRefPlane = findElement(typeof(ReferencePlane), "Reference Plane") as ReferencePlane;
          //SketchPlane pSketchPlane = _doc.FamilyCreate.NewSketchPlane( pRefPlane.Plane ); // 2013
          SketchPlane pSketchPlane = SketchPlane.Create( _doc, pRefPlane.Plane ); // 2014
    
          // (3) height of the extrusion
          //
          // once again, you will need to know your template. unlike UI, the alightment will not adjust the geometry.
          // You will need to have the exact location in order to set alignment.
          // Here we hard code for simplicity. 4000 is the distance between Lower and Upper Ref. Level.
          // as an exercise, try changing those values and see how it behaves.
          //
          double dHeight = mmToFeet(4000.0);
    
          // (4) create an extrusion here. at this point. just an box, nothing else.
          //
          bool bIsSolid = true;
          return _doc.FamilyCreate.NewExtrusion(bIsSolid, pProfile, pSketchPlane, dHeight);
        }
