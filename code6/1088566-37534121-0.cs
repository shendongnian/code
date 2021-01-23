     // using Mesh, a custom class of mine
    public List<GeometryModel3D> drawLeftHand(Hand hand) {
            List<GeometryModel3D> list = new List<GeometryModel3D>();
            for (int i = 0; i < hand.Fingers.Count; i++)
            {
               // material = materials[i];
                Finger finger = hand.Fingers[i];
                List<Bone> allBones = new List<Bone>();
                
                Bone _m = finger.Bone(Leap.Bone.BoneType.TYPE_METACARPAL);
                Bone _pp = finger.Bone(Leap.Bone.BoneType.TYPE_PROXIMAL);
                Bone _ip = finger.Bone(Leap.Bone.BoneType.TYPE_INTERMEDIATE);
                Bone _dp = finger.Bone(Leap.Bone.BoneType.TYPE_DISTAL);
                allBones.Add(_m);
                allBones.Add(_pp);
                allBones.Add(_ip);
                allBones.Add(_dp);
                
                for (int j = 0; j < allBones.Count; j++)
                {
                    material = materials[j];
                    if (allBones[j].IsValid)
                    {
                        Vector before = allBones[j].PrevJoint;
                        
                        GeometryModel3D sphere = new GeometryModel3D(mesh.createSphere(new Point3D(before.x, before.y, before.z)), material);
                        list.Add(sphere);
                        Vector after = allBones[j].NextJoint;
                        GeometryModel3D cylinder = new GeometryModel3D(mesh.createCylinder(new Point3D(before.x, before.y, before.z), new Point3D(after.x, after.y, after.z)), material);
                                list.Add(cylinder);
                                if (j == allBones.Count - 1)
                                {
                                    Vector last = allBones[j].NextJoint;
                                    GeometryModel3D _sphere = new GeometryModel3D(mesh.createSphere(new Point3D(last.x, last.y, last.z)), material);
                                    list.Add(_sphere);
                                }       
                    }
                }
            }
            return list;
        }
