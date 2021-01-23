    private void CreateObjects()
        {
            bowlingAlley = new Box(Vector3.One);
            Material bowlingAlleyMaterial = new Material();
            bowlingAlleyMaterial.Specular = Color.Brown.ToVector4();
            bowlingAlleyMaterial.Diffuse = Color.BurlyWood.ToVector4();
            bowlingAlleyMaterial.SpecularPower = 45;
            bowlingBall = new Sphere(3f, 50, 50);
            bowlingBallMaterial = new Material();
            bowlingBallMaterial.Specular = Color.Black.ToVector4();
            bowlingBallMaterial.Diffuse = Color.BlanchedAlmond.ToVector4();
            alleyGroundMarker = new MarkerNode(scene.MarkerTracker, "AlvarGroundArray.xml");
            
            groundNode = new GeometryNode("Ground");
            groundNode.Model = bowlingAlley;
            groundNode.Material = bowlingAlleyMaterial;
            groundNode.Physics.MaterialName = "Ground";
            groundNode.Physics.Interactable = true;
            groundNode.Physics.Collidable = true;
            groundNode.Physics.Shape = GoblinXNA.Physics.ShapeType.Box;            
            groundNode.AddToPhysicsEngine = true;
            
            // Create a parent transformation for both the ground and the sphere models
            TransformNode transformBowlingAlley = new TransformNode();
            transformBowlingAlley.Translation = new Vector3(0,-10,-20);
            // Create a scale transformation for the ground to make it bigger
            TransformNode groundScaleNode = new TransformNode();
            groundScaleNode.Scale = new Vector3(400, 400, 10);
            // Add this ground model to the scene
            scene.RootNode.AddChild(alleyGroundMarker);
            scene.RootNode.AddChild(transformBowlingAlley); 
            alleyGroundMarker.AddChild(groundScaleNode);
            groundScaleNode.AddChild(groundNode);
            
        }
 
