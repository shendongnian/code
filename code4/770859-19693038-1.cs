        public double RandomNormal(double mu, double sigma)
        {
            return NormalDistribution(rnd.NextDouble(), mu, sigma);
        }
        public double RandomNormal()
        {
            return RandomNormal(0d, 1d);
        }
        /// <summary>
        /// Normal distribution
        /// </summary>
        /// <arg name="probability">probability value 0..1</arg>
        /// <arg name="mean">mean value</arg>
        /// <arg name="sigma">std. deviation</arg>
        /// <returns>A normal distribution</returns>
        public double NormalDistribution(double probability, double mean, double sigma)
        {
            return mean+sigma*NormalDistribution(probability);
        }
        /// <summary>
        /// Normal distribution
        /// </summary>
        /// <arg name="probability">probability value 0.0 to 1.0</arg>
        /// <see cref="NormalDistribution(double,double,double)"/>
        public double NormalDistribution(double probability)
        {
            return Math.Sqrt(2)*InverseErrorFunction(2*probability-1);
        }
        public double InverseErrorFunction(double P)
        {
            double Y, A, B, X, Z, W, WI, SN, SD, F, Z2, SIGMA;
            const double A1=-.5751703, A2=-1.896513, A3=-.5496261E-1;
            const double B0=-.1137730, B1=-3.293474, B2=-2.374996, B3=-1.187515;
            const double C0=-.1146666, C1=-.1314774, C2=-.2368201, C3=.5073975e-1;
            const double D0=-44.27977, D1=21.98546, D2=-7.586103;
            const double E0=-.5668422E-1, E1=.3937021, E2=-.3166501, E3=.6208963E-1;
            const double F0=-6.266786, F1=4.666263, F2=-2.962883;
            const double G0=.1851159E-3, G1=-.2028152E-2, G2=-.1498384, G3=.1078639E-1;
            const double H0=.9952975E-1, H1=.5211733, H2=-.6888301E-1;
            X=P;
            SIGMA=Math.Sign(X);
            if(P<-1d||P>1d)
                throw new System.ArgumentException();
            Z=Math.Abs(X);
            if(Z>.85)
            {
                A=1-Z;
                B=Z;
                W=Math.Sqrt(-Math.Log(A+A*B));
                if(W>=2.5)
                {
                    if(W>=4.0)
                    {
                        WI=1.0/W;
                        SN=((G3*WI+G2)*WI+G1)*WI;
                        SD=((WI+H2)*WI+H1)*WI+H0;
                        F=W+W*(G0+SN/SD);
                    }
                    else
                    {
                        SN=((E3*W+E2)*W+E1)*W;
                        SD=((W+F2)*W+F1)*W+F0;
                        F=W+W*(E0+SN/SD);
                    }
                }
                else
                {
                    SN=((C3*W+C2)*W+C1)*W;
                    SD=((W+D2)*W+D1)*W+D0;
                    F=W+W*(C0+SN/SD);
                }
            }
            else
            {
                Z2=Z*Z;
                F=Z+Z*(B0+A1*Z2/(B1+Z2+A2/(B2+Z2+A3/(B3+Z2))));
            }
            Y=SIGMA*F;
            return Y;
        }
