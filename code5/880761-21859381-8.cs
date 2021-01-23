        vec3 u=(B-A).Normalized();
        
        vec3 n = vec3.O;
        if(Math.Abs(u.X)<=Math.Abs(u.Y)&&Math.Abs(u.X)<=Math.Abs(u.Z))
        {
            n=new vec3(u.Y*u.Y+u.Z*u.Z, -u.Y*u.X, -u.Z*u.X);
        }
        else if(Math.Abs(u.Y)<=Math.Abs(u.X)&&Math.Abs(u.Y)<=Math.Abs(u.Z))
        {
            n=new vec3(-u.X*u.Y, u.X*u.X+u.Z*u.Z, -u.Z*u.Y);
        }
        else if(Math.Abs(u.Z)<=Math.Abs(u.X)&&Math.Abs(u.Z)<=Math.Abs(u.Y))
        {
            n=new vec3(-u.X*u.Z, -u.Y*u.Z, u.X*u.X+u.Y*u.Y);
        }
        vec3 v=n.Cross(u);
        mat3 R=mat3.Combine(v, n, u);
        var a=A+R*new vec3(wt, ht, 0);
        var b=A+R*new vec3(-wt, ht, 0);
        var c=A+R*new vec3(wt, -ht, 0);
        var d=A+R*new vec3(-wt, -ht, 0);
        var e=B+R*new vec3(wt, ht, 0);
        var f=B+R*new vec3(-wt, ht, 0);
        var g=B+R*new vec3(wt, -ht, 0);
        var h=B+R*new vec3(-wt, -ht, 0);
