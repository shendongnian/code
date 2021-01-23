    public static Particle UpdateParticle(Particle p)
    {
        p.Position += p.Velocity;
        return p;
    }
