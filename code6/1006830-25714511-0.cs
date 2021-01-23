    foreach (ExtTerBody OtherObject in UniverseController.CurrentUniverse.ExterTerBodies.Where(x =>  x != this))
	{
	double massOther = OtherObject.Mass;
	double R = Vector2Math.Distance(Position, OtherObject.Position);
	double V = (massOther) / Math.Pow(R,2) * Time.DeltaTime;
	float VRmod = (float)Math.Round(V/(R*0.001), 0, MidpointRounding.AwayFromZero);
	if(V > R*0.01f)
	{
		for (int x = 0; x < VRmod; x++)
		{
			EulerMovement(OtherObject, Time.DeltaTime / VRmod);
		}
	}
	else
		EulerMovement(OtherObject, Time.DeltaTime);
	}
    public void EulerMovement(ExtTerBody OtherObject, float deltaTime)
		{
			
				double massOther = OtherObject.Mass;
				double R = Vector2Math.Distance(Position, OtherObject.Position);
				double V = (massOther) / Math.Pow(R, 2) * deltaTime;
				Vector2 NonNormTwo = (OtherObject.Position - Position).Normalized() * V;
				Vector2 NonNormDir = Velocity + NonNormTwo;
				Velocity = NonNormDir;
					
				//Debug.WriteLine("Velocity=" + Velocity);
				Position += Velocity * deltaTime;
		}
